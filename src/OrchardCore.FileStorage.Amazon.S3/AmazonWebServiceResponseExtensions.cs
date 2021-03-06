using Amazon.Runtime;

namespace OrchardCore.FileStorage.Amazon.S3
{
    using System.Net;
    
    public static class AmazonWebServiceResponseExtensions
    {
        public static bool IsSuccessful(this AmazonWebServiceResponse response) =>
            response.HttpStatusCode == HttpStatusCode.OK;
    }
}