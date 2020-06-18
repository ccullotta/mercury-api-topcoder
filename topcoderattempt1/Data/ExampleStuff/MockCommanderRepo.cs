using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Models;

namespace topcoderattempt1.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command
            {
                Id = 0,
                HowTo = "boil stuuff",
                Line = "boil",
                Platform = "Pot"
            },
                new Command
            {
                Id = 1,
                HowTo = "boil st2uuff",
                Line = "boil",
                Platform = "Pot1"
            },
             new Command
            {
                Id = 2,
                HowTo = "boil stu3suff",
                Line = "boil",
                Platform = "Pot2"
            },
        };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "boil stuuff",
                Line = "boil",
                Platform = "Pot"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
