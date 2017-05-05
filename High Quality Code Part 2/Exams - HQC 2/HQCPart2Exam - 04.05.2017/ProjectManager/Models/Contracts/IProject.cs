using System;
using System.Collections.Generic;

using ProjectManager.Models.Contracts;
using ProjectManager.Models.Enums;

namespace ProjectManager.Models
{
    public interface IProject
    {
        string Name { get; set; }

        DateTime StartingDate { get; set; }

        DateTime EndingDate { get; set; }

        State State { get; set; }

        IList<IUser> Users { get; set; }

        IList<ITask> Tasks { get; set; }
    }
}
