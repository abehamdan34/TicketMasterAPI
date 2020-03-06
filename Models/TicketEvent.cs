using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGroupProject.Models
{

    public class Rootobject
    {
        public _Links _links { get; set; }
        public _Embedded _embedded { get; set; }
        public Page page { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public Next next { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
        public bool templated { get; set; }
    }

    public class Next
    {
        public string href { get; set; }
        public bool templated { get; set; }
    }

    public class _Embedded
    {
        public Event[] events { get; set; }
    }

    public class Event
    {
        public string name { get; set; }
        public string locale { get; set; }
        public int[] promoterId { get; set; }
        public Dates dates { get; set; }
        public bool test { get; set; }
        public _Links1 _links { get; set; }
        public string id { get; set; }
        public _Embedded1 _embedded { get; set; }
        public string type { get; set; }
        public string eventUrl { get; set; }
        public Sales sales { get; set; }
    }

    public class Dates
    {
        public Start start { get; set; }
        public End end { get; set; }
        public string timezone { get; set; }
        public Displayoptions displayOptions { get; set; }
        public Status status { get; set; }
    }

    public class Start
    {
        public DateTime dateTime { get; set; }
        public string localDate { get; set; }
        public string localTime { get; set; }
    }

    public class End
    {
        public DateTime dateTime { get; set; }
        public string localDate { get; set; }
        public string localTime { get; set; }
    }

    public class Displayoptions
    {
        public Range range { get; set; }
    }

    public class Range
    {
        public string localStartDate { get; set; }
        public string localEndDate { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
    }

    public class _Links1
    {
        public Self1 self { get; set; }
        public object categories { get; set; }
        public object attractions { get; set; }
        public Venue venue { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }

    public class Venue
    {
        public string href { get; set; }
    }

    public class _Embedded1
    {
        public Venue1[] venue { get; set; }
        public Category[] categories { get; set; }
        public Attraction[] attractions { get; set; }
    }

    public class Venue1
    {
        public string name { get; set; }
        public int[] marketId { get; set; }
        public Country country { get; set; }
        public State state { get; set; }
        public City city { get; set; }
        public Location location { get; set; }
        public string postalCode { get; set; }
        public Address address { get; set; }
        public string timeZone { get; set; }
        public _Links2 _links { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Country
    {
        public string countryCode { get; set; }
    }

    public class State
    {
        public string stateCode { get; set; }
    }

    public class City
    {
        public string name { get; set; }
    }

    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Address
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
    }

    public class _Links2
    {
        public Self2 self { get; set; }
    }

    public class Self2
    {
        public string href { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public int level { get; set; }
        public _Links3 _links { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class _Links3
    {
        public Self3 self { get; set; }
    }

    public class Self3
    {
        public string href { get; set; }
    }

    public class Attraction
    {
        public string url { get; set; }
        public Image image { get; set; }
        public string name { get; set; }
        public _Links4 _links { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
    }

    public class _Links4
    {
        public Self4 self { get; set; }
    }

    public class Self4
    {
        public string href { get; set; }
    }

    public class Sales
    {
        public Public _public { get; set; }
    }

    public class Public
    {
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
    }

    public class Page
    {
        public int size { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int number { get; set; }
    }

}
