using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Repositories.Interface
{
    interface IKotaRepository
    {
        //GET
        List<Kota> Get();
        //GET BY ID
        Kota Get(int id);
        //POST
        int Post(Kota kota);
        //PUT
        int Put(int id, Kota kota);
        //DELETE
        int Delete(Kota kota);
    }
}
