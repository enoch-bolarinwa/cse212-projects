using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public class SymmetricPairsFinder
{
    public static List<string> FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            // Skip words with identical characters like "aa"
            if (word[0] == word[1]) continue;

            var reversed = new string(new char[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result;
    }

    // Example usage
    public static void Main()
    {
        string[] words = { "am", "at", "ma", "if", "fi" };
        var pairs = FindPairs(words);
        foreach (var pair in pairs)
        {
            Console.WriteLine(pair);
        }
    }
}

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degreeSummary = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            // Split on commas, adjust if using different delimiter
            var columns = line.Split(',');

            if (columns.Length < 4)
                continue; // Skip malformed lines

            string degree = columns[3].Trim();

            if (degreeSummary.ContainsKey(degree))
            {
                degreeSummary[degree]++;
            }
            else
            {
                degreeSummary[degree] = 1;
            }
        }

        return degreeSummary;

    }
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
   public class AnagramChecker
{
    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// Ignores spaces and is case-insensitive.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize: remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If lengths don't match after normalization, not anagrams
        if (word1.Length != word2.Length)
            return false;

        // Count characters in word1
        var charCount = new Dictionary<char, int>();
        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        // Subtract counts using word2
        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c))
                return false;

            charCount[c]--;

            if (charCount[c] < 0)
                return false;
        }

        // If all counts are zero, they are anagrams
        return true;
    }
}

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public class EarthquakeData
{
    public class FeatureCollection
    {
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public double? Mag { get; set; }
        public string Place { get; set; }
    }

    public static async Task<List<string>> EarthquakeDailySummary()
    {
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();

        try
        {
            var response = await client.GetStringAsync(url);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            FeatureCollection data = JsonSerializer.Deserialize<FeatureCollection>(response, options);

            var results = new List<string>();

            foreach (var feature in data.Features)
            {
                if (!string.IsNullOrWhiteSpace(feature.Properties.Place) && feature.Properties.Mag.HasValue)
                {
                    results.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag.Value}");
                }
            }

            return results;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error fetching or processing data: " + ex.Message);
            return new List<string>();
        }
    }
}