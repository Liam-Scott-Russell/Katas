using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _p;

        public Finder(List<Person> p)
        {
            _p = p;
        }

        public PairOfPeople Find(FT ft)
        {
            var tr = new List<PairOfPeople>();

            for(var i = 0; i < _p.Count - 1; i++)
            {
                for(var j = i + 1; j < _p.Count; j++)
                {
                    var r = new PairOfPeople();
                    if(_p[i].BirthDate < _p[j].BirthDate)
                    {
                        r.P1 = _p[i];
                        r.P2 = _p[j];
                    }
                    else
                    {
                        r.P1 = _p[j];
                        r.P2 = _p[i];
                    }
                    r.D = r.P2.BirthDate - r.P1.BirthDate;
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
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case FT.Two:
                        if(result.D > answer.D)
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