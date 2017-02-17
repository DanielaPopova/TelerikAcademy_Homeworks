namespace PackageManager.Repositories
{
    using System;
    using System.Collections.Generic;
    using Info.Contracts;
    using Models.Contracts;

    public class ExtendedPackageRepository : PackageRepository
    {
        public ExtendedPackageRepository(ILogger logger, ICollection<IPackage> packages = null)
            : base(logger, packages)
        {
        }
        
        public ILogger Logger
        {
            get
            {
                return base.logger;
            }
        }

        public ICollection<IPackage> Packages
        {
            get
            {
                return base.packages;
            }
        }
    }
}
