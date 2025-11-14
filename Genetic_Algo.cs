//a simple genetic algorithm in csharps blazor to run in browser

public class Genome
{
		public Random dice = new Random();
		public string logos { get; set; }
		public List<char> genetic_material = new List<char>();

		public void init(int dna_length)
		{
				for (int x = 0; x < dna_length; x++)
				{
						char[] tmp = logos.ToCharArray();
						var pick = tmp[dice.Next(tmp.Length - 1)];
						genetic_material.Add(pick);
				}
		}
		public void mutate(int mutation_rate)
		{
			for(int pos = 0; pos < genetic_material.Count()-1;pos++)
			{
				var chance = dice.Next(100);
				if (chance < mutation_rate)
				{
						var new_pick = dice.Next(logos.Count() - 1);
						genetic_material[pos] = logos[new_pick];
				}
			}
		}

		public Genome(string solution_space)
		{
				logos = solution_space;
		}
}


public class Population
{
		public List<Genome> all_genomes = new List<Genome>();
		public string logos { get; set; }
		public int dna_length { get; set; }

		public void init(int size)
		{
				for (int x = 0; x < size; x++)
				{
						Genome individual = new Genome(logos);
						individual.init(dna_length);
						all_genomes.Add(individual);
				}

		}

		public void evaluate(List<Genome> genomes, Action<Genome> fitness_function)
		{
				foreach (Genome g in genomes)
				{
						fitness_function(g);
				}
		}


		public void crossover(Genome a, Genome b)
		{
				Genome[] children = new Genome[2];
				var a_dna = a.genetic_material;
				var b_dna = b.genetic_material;
				var cut_pos = a.dice.Next(a.genetic_material.Count() - 1);

				for (int x = 0; x < a_dna.Count() - 1; x++)
				{
						if (x < cut_pos)
						{
								a_dna[x] = b_dna[x];
						}
						else
						{
								b_dna[x] = a_dna[x];
						}
				}

		}

		public Population(string solution_space, int dna_length, int population_size)
		{
				logos = solution_space;
				this.dna_length = dna_length;
		}

}

