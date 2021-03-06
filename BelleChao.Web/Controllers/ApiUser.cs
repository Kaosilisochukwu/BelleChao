﻿using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using BelleChao.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ApiUser : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CloudinaryConfig _cloudinryConfig;

        public ApiUser(UserManager<ApplicationUser> userManager, CloudinaryConfig cloudinryConfig)
        {
            _userManager = userManager;
            _cloudinryConfig = cloudinryConfig;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPut("{Id}/update")]
        public async Task<IActionResult> UpdateProfile(string Id, UsertoUpdate model)
        {
            var user = _userManager.Users.FirstOrDefault(user => user.Id == Id);
            if(user == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.City = model.City;
                user.State = model.State;
                user.PhoneNumber = model.PhoneNumber;
                user.Address = model.Address;
                await _userManager.UpdateAsync(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{Id}/updatephoto")]
        public async Task<IActionResult> UpdatePhoto(string Id, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(user => user.Id == Id);
                if(user == null)
                {
                    return BadRequest();
                }
                var deletionResult = _cloudinryConfig.DeletePhoto(user.PhotoPublicId);
                if(deletionResult.Status == TaskStatus.RanToCompletion)
                {
                    var upoadResult = await _cloudinryConfig.UploadPhoto(photo);
                    if(upoadResult.StatusCode == HttpStatusCode.OK)
                    {
                        user.PhotoUrl = upoadResult.Url.ToString();
                        user.PhotoPublicId = upoadResult.PublicId;
                        await _userManager.UpdateAsync(user);
                        return Ok();
                    }
                }
                else
                {
                    await UpdatePhoto(Id, photo);
                }
            }
            return Ok();
        }

        [HttpDelete("{id}/deletephoto")]
        public async Task<IActionResult> DeleteProfilePicture(string id)
        {
            var user = _userManager.Users.FirstOrDefault(user => user.Id == id);
            if(user == null)
            {
                return BadRequest();
            }
            var deletionResult = await _cloudinryConfig.DeletePhoto(user.PhotoPublicId);
            user.PhotoPublicId = null;
            user.PhotoUrl = null;
            var userUpdateResult = await _userManager.UpdateAsync(user);
            if (userUpdateResult.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}/changePassword")]
        public async Task<IActionResult> ChangePassword(string Id, PasswordChangeDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.Users.FirstOrDefault(user => user.Id == Id);
                    await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
