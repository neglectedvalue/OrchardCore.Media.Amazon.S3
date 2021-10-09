using Amazon.Runtime;

namespace OrchardCore.FileStorage.Amazon.S3
{
    using System.Net;
    
    public static class AwsResponseExtensions
    {
        public static bool IsSuccessful(this AmazonWebServiceResponse response)
        {
            return response.HttpStatusCode == HttpStatusCode.OK;
        }
    }
}