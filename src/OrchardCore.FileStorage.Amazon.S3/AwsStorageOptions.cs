﻿namespace OrchardCore.FileStorage.Amazon.S3
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// AWS storage options.
    /// </summary>
    public class AwsStorageOptions 
    {
        /// <summary>
        /// AWS S3 bucket name.
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// The base directory path to use inside the container for this stores contents.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets the credentials.
        /// <remarks>
        /// Credentials section can be set directly via configuration or get loaded from the configured ProfileName.
        /// For development purpose it is recommended to specify just ProfileName.
        /// For Prod Env this section should be null, AWS SDK Services will get the default credentials from Env variables
        /// </remarks>
        /// </summary>
        public AwsStorageCredentials Credentials { get; set; }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <returns>
        /// The collection of errors.
        /// </returns>
        public IEnumerable<ValidationResult> Validate()
        {
            if (string.IsNullOrWhiteSpace(BucketName))
            {
                yield return new ValidationResult(Constants.ValidationMessages.BucketNameIsEmpty);
            }

            if (Credentials != null)
            {
                if (string.IsNullOrWhiteSpace(Credentials.SecretKey))
                {
                    yield return new ValidationResult(Constants.ValidationMessages.SecretKeyIsEmpty);
                }
                
                if (string.IsNullOrWhiteSpace(Credentials.AccessKeyId))
                {
                    yield return new ValidationResult("AccessKeyId is required attribute for S3 Media, make sure it exists in Credentials section or ProfileName you specified");
                }
                
                if (string.IsNullOrWhiteSpace(Credentials.RegionEndpoint))
                {
                    yield return new ValidationResult("Region is required attribute for S3 Media, make sure it exists in Credentials section or ProfileName you specified");
                }
            }
        }
    }

    /// <summary>
    /// The AWS storage credentials.
    /// </summary>
    public class AwsStorageCredentials
    {
        /// <summary>
        /// AWS region name
        /// </summary>
        public string RegionEndpoint { get; set; }
        
        /// <summary>
        /// AWS account secret key. Do not use root's user secret key! 
        /// </summary>
        public string SecretKey { get; set; }
        
        /// <summary>
        /// AWS account access key Id.
        /// </summary>
        public string AccessKeyId { get; set; }
    }
}