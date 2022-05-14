using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask2.Model
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string Email { get; set; }
    }
}
