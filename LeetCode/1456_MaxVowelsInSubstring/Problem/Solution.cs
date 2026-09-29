public class Solution
{
    public int MaxVowels(string s, int k)
    {
        int l = 0;
        int count = 0;

        for (int i = 0; i < k; i++)
        {
            if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
            {
                count++;
            }
        }

        int maxcount = count;
        int r = k - 1;

        while (r < s.Length - 1)
        {
            if (s[l] == 'a' || s[l] == 'e' || s[l] == 'i' || s[l] == 'o' || s[l] == 'u')
            {
                count--;
            }

            l++;
            r++;

            if (s[r] == 'a' || s[r] == 'e' || s[r] == 'i' || s[r] == 'o' || s[r] == 'u')
            {
                count++;
            }

            maxcount = Math.Max(count, maxcount);
        }

        return maxcount;
    }
}