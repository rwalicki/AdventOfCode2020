using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Puzzles.Day2.Services
{
    public class PasswordValidator
    {
        public int GetValidPasswords(List<string> list)
        {
            list.RemoveAll(x => string.IsNullOrEmpty(x));
            return list.Where(x => IsValid(x)).Count();
        }

        private bool IsValid(string data)
        {
            var parts = data.Split(" ");

            var signPolicy = parts[0];
            var sign = parts[1].Substring(0, 1);
            var password = parts[2];

            var minSignPresence = int.Parse(signPolicy.Split("-")[0]);
            var maxSignPresence = int.Parse(signPolicy.Split("-")[1]);

            var signPresence = password.ToList().Where(x => x.ToString() == sign).ToList();
            return signPresence.Count >= minSignPresence && signPresence.Count <= maxSignPresence;
        }
    }
}