/*
2. Add Two Numbers

You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:
    Input: l1 = [2,4,3], l2 = [5,6,4]
    Output: [7,0,8]
    Explanation: 342 + 465 = 807.

Example 2:
    Input: l1 = [0], l2 = [0]
    Output: [0]

Example 3:
    Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    Output: [8,9,9,9,0,0,0,1]

Constraints:
    The number of nodes in each linked list is in the range [1, 100].
    0 <= Node.val <= 9
    It is guaranteed that the list represents a number that does not have leading zeros.

https://leetcode.com/problems/add-two-numbers/description/
*/
namespace LeetCodeProblems.Problems;

public class AddTwoNumbers
{
    public static ListNode? AddTwoNumberss(ListNode? l1, ListNode? l2)
    {
        if (l1 is null) return l2;
        if (l2 is null) return l1;

        ListNode? result = new(0);
        ListNode? temp = result;
        int carry = 0;
        int sum;
        while (l1 is not null && l2 is not null)
        {
            sum = l1.val + l2.val + carry;
            temp.next = new(sum % 10);
            temp = temp.next;
            carry = sum / 10;
            l1 = l1.next;
            l2 = l2.next;
        }

        if (l1 is null)
        {
            if (carry != 0)
            {
                while (l2 is not null)
                {
                    sum = l2.val + carry;
                    temp.next = new(sum % 10);
                    temp = temp.next;
                    l2 = l2.next;
                }
            }
            else
            {
                temp.next = l2;
            }
        }
        else if (l2 is null)
        {
            if (carry != 0)
            {
                while (l1 is not null)
                {
                    sum = l1.val + carry;
                    temp.next = new(sum % 10);
                    temp = temp.next;
                    l1 = l1.next;
                }
            }
            else
            {
                temp.next = l1;
            }
        }

        if (carry != 0)
        {
            temp.next = new(carry);
        }

        return result.next;
    }

    public static void TestAddTwoNumberss()
    {
        var testData = new (ListNode l1, ListNode l2, ListNode sum)[]
            {
                (new ([2,4,3]), new([5,6,4]), new([7,0,8])),
                (new([0]), new([0]), new([0])),
                (new([9,9,9,9,9,9,9]), new([9,9,9,9]), new([8,9,9,9,0,0,0,1])), // l1 bigger with carry
                (new([9,9,9,9]), new([9,9,9,9,9,9,9]), new([8,9,9,9,0,0,0,1])), // l2 bigger with carry
                (new([9,9,9,9]), new([9,9,9,9]), new([8,9,9,9,1])), // l1 and l2 equal length with carry
                (new([1,1,1,1]), new([1,1,1,1]), new([2,2,2,2])), // l1 and l2 equal length with no carry
                (new([1,1]), new([1,1,1,1]), new([2,2,1,1])), // l2 bigger with no carry
                (new([1,1,1,1]), new([1,1]), new([2,2,1,1])) // l1 bigger with no carry
            };

        for (int i = 0; i < testData.Length; i++)
        {
            bool testResult = true;
            ListNode? output = AddTwoNumberss(testData[i].l1, testData[i].l2);
            ListNode? expected = testData[i].sum;
            while (expected is not null && output is not null)
            {
                if (expected.val != output?.val)
                {
                    testResult = false;
                    break;
                }
                expected = expected.next;
                output = output.next;
            }
            Console.WriteLine($"{i}: {testResult}");
        }
    }
}
