using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVejrApp
{
        public class SmartVejrAppRepository
        {
            private int _nextId = 1;
            private readonly List<Weather> _weathers = new();
            public SmartVejrAppRepository()
            { // create 4 weather as listed.
                _weathers.Add(new Weather() { Id = _nextId++, Tempature = 20, Humidity = 50, Timestamp = DateTime.Now });
                _weathers.Add(new Weather() { Id = _nextId++, Tempature = 20, Humidity = 51, Timestamp = DateTime.Now });
            }
            // Get all weathers
            public List<Weather> GetAll()
            {
                return new List<Weather>(_weathers); // Kopi af weathers
            }

            // Get weather by id
            public Weather? GetById(int id)
            {
                return _weathers.Find(weather => weather.Id == id);
            }

            // add
            public Weather Add(Weather weather)
            {
                weather.Id = _nextId++;
                _weathers.Add(weather);
                return weather;
            }

            // Update
            public Weather? Update(int id, Weather weather)
            {
                Weather? weatherExist = GetById(id);
                if (weatherExist == null)
                {
                    return null;
                }
                weatherExist.Tempature = weather.Tempature;
                weatherExist.Humidity = weather.Humidity;
                weatherExist.Timestamp = weather.Timestamp;
                    return weatherExist;
            }
        }
}
