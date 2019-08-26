using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Week5_InterstellarTravel.Models;
using System.ComponentModel;

namespace Week5_InterstellarTravel.DAL
{
    //
    // this dummy class is used in place of a database to develop the 'look and feel' of a site 
    // without the need for a DB connection
    public class DummyDb : IDestinationsDataAccess
    {
        const string Lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        const string ShortLorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

        private Models.Destination[] m_destinations;

        public DummyDb()
        {
            int id = 0;
            m_destinations = new Models.Destination[] {
                CreateDummyDestination(id++, "Europa", "https://www.jpl.nasa.gov/visions-of-the-future/images/europa-small.jpg", 80000000),
                CreateDummyDestination(id++, "Mars", "https://www.jpl.nasa.gov/visions-of-the-future/images/mars-small.jpg", 80000000),
                CreateDummyDestination(id++, "Earth", "https://www.jpl.nasa.gov/visions-of-the-future/images/earth-small.jpg", 80000000),
                CreateDummyDestination(id++, "Trappist", "https://www.jpl.nasa.gov/visions-of-the-future/images/trappist-small.jpg", 80000000),
                CreateDummyDestination(id++, "Ceres", "https://www.jpl.nasa.gov/visions-of-the-future/images/ceres-small.jpg", 80000000),
                CreateDummyDestination(id++, "SuperEarth", "https://www.jpl.nasa.gov/visions-of-the-future/images/superearth-small.jpg", 80000000) };

        }

        private Models.Destination CreateDummyDestination(int id, string name, string imageUrl, long distance)
        {

            Models.Destination destination = new Models.Destination() { Id = id, DistanceInKm = distance, ImagePath = imageUrl, LongDescription = Lorem, Name = name, ShortDescription = ShortLorem };
            return destination;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Models.Destination> GetDestinations()
        {
            return m_destinations;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.Destination GetDestinationById(int id)
        {
            return Array.Find(m_destinations, d => { return d.Id == id; });
        }
    }
}