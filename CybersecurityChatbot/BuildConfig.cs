using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbot
{
    // This file controls features for GitHub Actions build
    public static class BuildConfig
    {
        public static bool IsGitHubActions => Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
    }
}
