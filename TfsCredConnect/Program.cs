using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;

namespace TfsCredConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const String c_collectionUri = "https://vsogd.visualstudio.com";
            const String c_projectName = "ServicesCode-Assets";
            const String c_repoName = "CDCO-MSDP";

            // Interactively ask the user for credentials, caching them so the user isn't constantly prompted
            VssCredentials creds = new VssClientCredentials();
            creds.Storage = new VssClientCredentialStorage();

            // Connect to Azure DevOps Services
            VssConnection connection = new VssConnection(new Uri(c_collectionUri), creds);

            // Get a GitHttpClient to talk to the Git endpoints
            GitHttpClient gitClient = connection.GetClient<GitHttpClient>();
            var repo = gitClient.GetRepositoryAsync(c_projectName, c_repoName).Result;
        }
    }
}
