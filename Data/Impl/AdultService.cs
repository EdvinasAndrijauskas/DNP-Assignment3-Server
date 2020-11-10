using System;
using System.Collections.Generic;
using Models;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment3.Persistence;


namespace Managing_Adults.Data.Impl
{
    public class AdultService : IAdultService
    {
        private FileContext _fileContext;
        private IList<Adult> _adults;

        public AdultService(FileContext fileContext)
        {
            _fileContext = fileContext;
            _adults = fileContext.Adults;
        }

        public void SaveChanges()
        {
            _fileContext.SaveChanges();
        }

        public async Task<IList<Adult>> GetAdultAsync()
        {
            List<Adult> tmp = new List<Adult>(_adults);
            return tmp;
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            int maxFamilyId = _adults.Max(adult => adult.Id);
            adult.Id = (++maxFamilyId);
            _adults.Add(adult);
            SaveChanges();
            Console.Out.WriteLine(adult);
            return adult;
        }

        public async Task<Adult> RemoveAdultAsync(int adultId)
        {
            Adult adultToRemove = _adults.First(adult => adult.Id == adultId);
            _adults.Remove(adultToRemove);
            SaveChanges();
            return adultToRemove;
        }
    }
}