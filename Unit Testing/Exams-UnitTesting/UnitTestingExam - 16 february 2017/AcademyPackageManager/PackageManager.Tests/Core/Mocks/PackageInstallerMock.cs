namespace PackageManager.Tests.Core.Mocks
{
    using PackageManager.Core;
    using System;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using Info.Contracts;

    internal class PackageInstallerMock : PackageInstaller
    {
        public PackageInstallerMock(IDownloader downloader, IProject project)
            : base(downloader, project)
        {
        }

        public IDownloader Downloader
        {
            get
            {
                return base.downloader;
            }
        }

        public IProject Project
        {
            get
            {
                return base.project;
            }
        }
    }
}
