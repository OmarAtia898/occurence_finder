using System;
using System.Collections.Generic;

// Function to find the maximum occurrence of a substring from t in z.
// t'den bir alt dizenin z içinde maksimum tekrarını bulmak için bir fonksiyon.
int FindOccurrence(string mainString, string subString)
{
    int maxOccurrence = 0; // Maximum occurrence of substring. Alt dizenin maksimum tekrar sayısı.
    int subStringLength = subString.Length; // Length of the substring. Alt dizenin uzunluğu.

    // Loop to iterate through all possible substrings of t in mainString.
    // Ana dizenin tüm olası alt dize parçaları üzerinde döngü yapılır.
    for (int i = 0; i <= mainString.Length - subStringLength; i++)
    {
        // Loop to check possible substrings of mainString.
        // Ana dizenin olası alt dize parçalarını kontrol etmek için döngü.

        for (int j = subStringLength; j > 0; j--)
        {
            // Generate a potential substring.
            // Potansiyel bir alt dize oluşturulur.
            string potentialSubstring = mainString.Substring(i, j);

            // Check if the substring exists in the main string.
            // Alt dizenin ana dize içinde var olup olmadığı kontrol edilir.
            if (subString.Contains(potentialSubstring))
            {
                // Call CountOccurrences function to count all occurrences of the substring in the main string.
                // Alt dizenin ana dize içindeki tüm tekrarlarını saymak için CountOccurrences fonksiyonu çağırılır.
                int occurrence = CountOccurrences(mainString, potentialSubstring);

                // Calculate the potential occurrence by multiplying the length of the substring with its count.
                // Potansiyel tekrar sayısını alt dizenin uzunluğu ile çarparak hesaplanır.
                int potantialOccurrence = j * occurrence;

                // Update the maximum occurrence if the potential occurrence exceeds the current maximum.
                // Eğer potansiyel tekrar sayısı mevcut maksimumu aşarsa, maksimum güncellenir.
                if (potantialOccurrence > maxOccurrence)
                {
                    maxOccurrence = potantialOccurrence;
                }
                // Break the loop as it's not logical to check for occurrences of smaller substrings.
                // Döngüden çıkılır, çünkü daha küçük alt dizelerin tekrarlarını kontrol etmek mantıklı değildir.
                break;
            }
        }
    }

    // Return the maximum occurrence.
    // Maksimum tekrar sayısı döndürülür.
    return maxOccurrence;
}

// Function to count occurrences of a substring in a main string.
// Bir alt dizenin bir ana dizede kaç kez tekrarlandığını sayan bir fonksiyon.
int CountOccurrences(string mainString, string subString)
{
    int count = 0; // Counter for occurrences. Tekrarlar için sayaç.
    int index = 0; // Index for searching. Arama için indeks.

    // Loop to search within the main string.
    // Ana dize içinde arama yapmak için döngü.
    while ((index = mainString.IndexOf(subString, index)) != -1)
    {
        // Find the next possible position of the substring.
        // Alt dizenin sonraki olası pozisyonunu bulunur.
        index += subString.Length;

        // Increment the count of occurrences.
        // Tekrar sayısı artırılır.
        count++;
    }
    // Return the count of occurrences.
    // Tekrar sayısı döndürülür.
    return count;
}

// Main method
// Ana metot
var t = "acldm1labcdhsnd";
var z = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";

// Call the FindOccurrence function and print the result.
// FindOccurrence fonksiyonunu çağır ve sonucu yazdır.
Console.WriteLine(FindOccurrence(z, t));