using Login.Context;
using Login.Models;
using Login.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Repositories.Data
{
    public class KotaRepository : IKotaRepository
    {
        MyContext myContext;
        public KotaRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(Kota kota)
        {
            myContext.Perkotaan.Remove(kota);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Kota> Get()
        {
            var data = myContext.Perkotaan.Include(x => x.Region).ToList();
            return data;
        }

        public Kota Get(int id)
        {
            var data = myContext.Perkotaan.Include(x => x.Region).Where(x => x.Id.Equals(id)).FirstOrDefault();
            return data;
        }

        public int Post(Kota kota)
        {
            myContext.Perkotaan.Add(kota);
            var result = myContext.SaveChanges();
                return result;
        }

        public int Put(int id, Kota kota)
        {
            var data = myContext.Perkotaan.Find(id);
            data.Name = kota.Name;
            data.RegionId = kota.RegionId;
            myContext.Perkotaan.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
