using BelleChao.Data.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Utilities
{
    public class CloudinaryConfig
    {
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        public CloudinaryConfig(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            Account account = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(account);
        }

        public ImageUploadResult UploadPhoto(IFormFile avarta)
        {
            var uploadResult = new ImageUploadResult();

            using (var stream = avarta.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(avarta.Name, stream),
                    //Transformation = new Transformation()
                    //                    .Width(500)
                    //                    .Height(500)
                    //                    .Crop("fill")
                    //                    .Gravity("face")
                };
                uploadResult = _cloudinary.Upload(uploadParams);
            }

            return uploadResult;
        }
    }
}
