using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_19_OOP_Danylko
{
    public partial class Form1 : Form
    {
        private List<string> wordsList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text.Trim();
            string[] words = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            wordsList.AddRange(words);
            UpdateWords();
            CountWordsOccurrences();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int index) && index > 0 && index < wordsList.Count)
            {
                wordsList.RemoveAt(index-1);
                UpdateWords();
                CountWordsOccurrences();
            }
            else
            {
                MessageBox.Show("Введіть коректний номер слова для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateWords()
        {
            textBox4.Text = string.Join(", ", wordsList);
        }

        private void CountWordsOccurrences()
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in wordsList)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            textBox2.Clear();
            foreach (var entry in wordCounts)
            {
                if (entry.Value > 1)
                {
                    textBox2.AppendText($"{entry.Key}: {entry.Value}" + Environment.NewLine);
                }
            }
        }
    }
}
