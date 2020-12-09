using Okko.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public class PersonDummyEndpoint : IPersonEndpoint
    {
        private List<IPersonModel> people = new List<IPersonModel>();
        private int currentId = 0;

        public Task CreatePerson(IPersonModel person, string recordUse)
        {
            return Task.Run(() => {
                currentId += 1;
                person.Id = currentId;
                people.Add(person);
            });
        }

        public Task DeletePerson(int id)
        {
            return Task.Run(() => { people.Remove(people.Where(x => x.Id == id).FirstOrDefault()); });
        }

        public Task<List<IPersonModel>> ReadPerson()
        {
            return Task.FromResult(people);
        }

        public Task<IPersonModel> ReadPerson(int id)
        {
            return Task.FromResult(people.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<List<IPersonModel>> SearchPerson(string searchTerm)
        {
            return Task.FromResult(people.Where(x => x.Firstname.Contains(searchTerm) ||
                x.Lastname.Contains(searchTerm)).ToList());
        }

        public Task UpdatePerson(IPersonModel person, string recordUser)
        {
            return Task.Run(() => {
                var p = people.Where(x => x.Id == person.Id).FirstOrDefault();
                if (p != null)
                {
                    p.Firstname = person.Firstname;
                    p.Lastname = person.Lastname;
                    p.IPT = person.IPT;
                    p.CellPhone = person.CellPhone;
                    p.LocationId = person.LocationId;
                    p.TitleId = person.TitleId;
                    p.PositionId = person.PositionId;
                    p.DateOfBirth = person.DateOfBirth;
                }
            });
        }
    }
}
