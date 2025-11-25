using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Exercises
{
    public class TwoSums
    {

        public TwoSums()
        {
            Console.WriteLine("Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.");
            Console.WriteLine("You may assume that each input would have exactly one solution, and you may not use the same element twice.");
            Console.WriteLine("You can return the answer in any order.\n");

            Console.WriteLine("Example 1:");
            var nums1 = new int[] { 2, 7, 11, 15 };
            var target1 = 9;
            var result1 = FindTwoSumForEach(new int[] { 2, 7, 11, 15 }, 9);

            Console.WriteLine($"Input: nums = [{string.Join(", ", nums1)}], target = {target1}");
            Console.WriteLine($"Output: [{result1[0]}, {result1[1]}] \n");


            Console.WriteLine("Example 2:");
            var nums2 = new int[] { 3, 2, 4 };
            var target2 = 6;
            var result2 = FindTwoSumForEach(nums2, target2);

            Console.WriteLine($"Input nums2 = [{string.Join(", ", nums2)}], target = {target2}");
            Console.WriteLine($"Output: [{result2[0]}, {result2[1]}] \n");

            Console.WriteLine("Example 3:");
            var nums3 = new int[] { 3, 3 };
            var target3 = 6;
            var result3 =  string.Join( ", ", FindTwoSumForEach(nums3, target3));

            Console.WriteLine($"Input nums 3= [{string.Join(", ", nums3)}], target = {target3}");
            Console.WriteLine($"Output: [{result3}] \n");

            Console.ReadLine();

        }

        public int[] FindTwoSumForEach(int[] nums, int target)
        {
            Dictionary<int,int> map = new Dictionary<int,int>();

            for(int i = 0; i < nums.Length; i++)
            {
                int num = target - nums[i];
                if (map.TryGetValue(num, out int index))
                {
                    return new int[] { i, index };
                }
                else map[nums[i]] = i;
            }
            return new int[2];
        }

        public int[] FindTwoSumFor(int[] nums, int target)
        {
            // Your code goes here
            for(int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                       return new int[] {i,j};
                    }
                }

            }

            return new int[0];
        }
    }

}