namespace PackageManager.Commands
{
    using System;
    using Core.Contracts;
    using Models.Contracts;

    internal class ExtendedInstallCommand : InstallCommand
    {
        public ExtendedInstallCommand(IInstaller<IPackage> installer, IPackage package)
            : base(installer, package)
        {
        }

        public IInstaller<IPackage> Installer
        {
            get
            {
                return base.installer;
            }
        }

        public IPackage Package
        {
            get
            {
                return base.package;
            }
        }
    }
}
