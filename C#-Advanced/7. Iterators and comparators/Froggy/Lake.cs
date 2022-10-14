using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] nums;

        public Lake(int[] numbers)
        {
            nums = new int[numbers.Length];
            nums = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < nums.Length; i += 2)
            {
                yield return nums[i];
            }

            if (nums.Length % 2 == 0)
            {
                for (int i = nums.Length - 1; i >= 1; i -= 2)
                {
                    yield return nums[i];
                }
            }

            else
            {
                for (int i = nums.Length - 2; i >= 1; i -= 2)
                {
                    yield return nums[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
