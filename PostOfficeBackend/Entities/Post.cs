﻿namespace PostOfficeBackend.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public int Capacity { get; set; }
        public string Code { get; set; }

        //public List<Parcel> Parcels { get; set; }
    }
}
