using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _allPeople;

        public Finder(List<Person> allPeople)
        {
            _allPeople = allPeople;
        }

        public PairOfPeople Find(AgeDifference ageDifference)
        {
            var pairOfPeoples = new List<PairOfPeople>();

            for(var i = 0; i < _allPeople.Count - 1; i++)
            {
                for(var j = i + 1; j < _allPeople.Count; j++)
                {
                    var currentPair = new PairOfPeople();
                    if(_allPeople[i].BirthDate < _allPeople[j].BirthDate)
                    {
                        currentPair.FirstPerson = _allPeople[i];
                        currentPair.SecondPerson = _allPeople[j];
                    }
                    else
                    {
                        currentPair.FirstPerson = _allPeople[j];
                        currentPair.SecondPerson = _allPeople[i];
                    }
                    currentPair.AgeDifference = currentPair.SecondPerson.BirthDate - currentPair.FirstPerson.BirthDate;
                    pairOfPeoples.Add(currentPair);
                }
            }

            if(pairOfPeoples.Count < 1)
            {
                return new PairOfPeople();
            }

            PairOfPeople target = pairOfPeoples[0];
            foreach(var current in pairOfPeoples)
            {
                switch(ageDifference)
                {
                    case AgeDifference.Smallest:
                        if(current.AgeDifference < target.AgeDifference)
                        {
                            target = current;
                        }
                        break;

                    case AgeDifference.Largest:
                        if(current.AgeDifference > target.AgeDifference)
                        {
                            target = current;
                        }
                        break;
                }
            }

            return target;
        }
    }
}