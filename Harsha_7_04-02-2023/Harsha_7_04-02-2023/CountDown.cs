namespace Harsha_7_04_02_2023
{
    public class CountDown
    {
        public static int[][] CountSequence(int[] sequence)
        {
            List<int[]> sequences = new List<int[]>();
            List<int> currentSequence = new List<int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                int length = 1;
                for (int j = i + 1; j < sequence.Length; j++)
                {
                    if (sequence[j] == sequence[j - 1] - 1)
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (length >= 2)
                {
                    int[] seq = new int[length];
                    for (int k = 0; k < length; k++)
                    {
                        seq[k] = sequence[i + k];
                    }
                    sequences.Add(seq);
                    i += length - 1;
                }
                else if (currentSequence.Count == 0 || sequence[i] == currentSequence[currentSequence.Count - 1] - 1)
                {
                    currentSequence.Add(sequence[i]);
                }
                else
                {
                    if (currentSequence.Count > 0 && sequence[i] == 1)
                    {
                        sequences.Add(currentSequence.ToArray());
                        currentSequence.Add(sequence[i]);
                    }
                }
            }
            int[][] result = new int[sequences.Count + 1][];
            result[0] = new int[] { sequences.Count };
            for (int l = 0; l < sequences.Count; l++)
            {
                result[l + 1] = sequences[l];
            }
            return result;
        }
    }
}


