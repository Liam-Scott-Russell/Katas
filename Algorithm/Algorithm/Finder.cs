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

        public PairOfPeople Find(FT ft)
        {
            var tr = new List<PairOfPeople>();

            for(var i = 0; i < _allPeople.Count - 1; i++)
            {
                for(var j = i + 1; j < _allPeople.Count; j++)
                {
                    var r = new PairOfPeople();
                    if(_allPeople[i].BirthDate < _allPeople[j].BirthDate)
                    {
                        r.FirstPerson = _allPeople[i];
                        r.SecondPerson = _allPeople[j];
                    }
                    else
                    {
                        r.FirstPerson = _allPeople[j];
                        r.SecondPerson = _allPeople[i];
                    }
                    r.AgeDifference = r.SecondPerson.BirthDate - r.FirstPerson.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new PairOfPeople();
            }

            PairOfPeople answer = tr[0];
            foreach(var result in tr)
            {
                switch(ft)
                {
                    case FT.One:
                        if(result.AgeDifference < answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;

                    case FT.Two:
                        if(result.AgeDifference > answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}