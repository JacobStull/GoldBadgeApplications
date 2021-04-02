using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class KGPRepo
    {
        private List<KomodoGreen> _contentDirectory = new List<KomodoGreen>();
        public bool AddContentToDirectory(KomodoGreen content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<KomodoGreen> GetContents()
        {
            return _contentDirectory;
        }
        public KomodoGreen GetContentByFuel(string fuel)
        {
            foreach (KomodoGreen content in _contentDirectory)
            {
                if (content.Fuel.ToLower() == fuel.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
        public KomodoGreen GetContentByModel(string model)
        {
            foreach (KomodoGreen content in _contentDirectory)
            {
                if (content.Model.ToLower() == model.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
        public bool DeleteExistingContent(KomodoGreen existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
    public class KomodoGreen
    {
        public string Fuel { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
       
        public KomodoGreen() { }
        public KomodoGreen(string model, string description, string make, string fuel)
        {
            Model = model;
            Description = description;
            Make = make;
            Fuel = fuel;
        }
    }
    /*public enum Type
    {
        Gas = 1,
        Hybrid,
        Electric,
    }*/
}
