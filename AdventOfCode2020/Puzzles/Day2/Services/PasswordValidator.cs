using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Puzzles.Day2.Services
{
    public class PasswordValidator
    {
        public int GetValidPasswordsOldJobPolicy(List<string> list)
        {
            list.RemoveAll(x => string.IsNullOrEmpty(x));
            return list.Where(x => IsValidOldJobPolicy(x)).Count();
        }

        private bool IsValidOldJobPolicy(string data)
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

        public int GetValidPasswordsNewJobPolicy(List<string> list)
        {
            list.RemoveAll(x => string.IsNullOrEmpty(x));
            return list.Where(x => IsValidNewJobPolicy(x)).Count();
        }

        private bool IsValidNewJobPolicy(string data)
        {
            var parts = data.Split(" ");

            var signPolicy = parts[0];
            var sign = parts[1].Substring(0, 1);
            var password = parts[2];

            var positionOneSignPresence = int.Parse(signPolicy.Split("-")[0]);
            var positionTwoSignPresence = int.Parse(signPolicy.Split("-")[1]);

            var res1 = password.ToList()[positionOneSignPresence - 1].ToString() == sign;
            var res2 = password.ToList()[positionTwoSignPresence - 1].ToString() == sign;

            return res1 ^ res2;
        }
    }
}