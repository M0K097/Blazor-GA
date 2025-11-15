//a simple genetic algorithm in C#'s Blazor to run in browser
public class Genome
{
		public Random dice = new Random();
		public string logos { get; set; }
		public List<char> genetic_material = new List<char>();
		public int score;

		public void init(int dna_length)
		{
			for (int x = 0; x < dna_length; x++)
			{
				char[] tmp = logos.ToCharArray();
				var pick = tmp[dice.Next(tmp.Length )];
				genetic_material.Add(pick);
			}
		}

		public string get_dna()
		{
			string dna = new string(genetic_material.ToArray());
			return dna;
		}

		public void mutate(int mutation_rate)
		{
			for(int pos = 0; pos < genetic_material.Count()-1;pos++)
			{
				var chance = dice.Next(100);
				if (chance <= mutation_rate)
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
		Random rnd = new Random();

		public void init(int size)
		{
			for (int x = 0; x < size; x++)
			{
				Genome individual = new Genome(logos);
				individual.init(dna_length);
				all_genomes.Add(individual);
			}
		}

		public void evaluate(Func<Genome,int> fitness_function)
		{
			foreach(Genome g in all_genomes)
			{
				g.score = fitness_function(g);
			}
		}

		public void sort_by_score()
		{
			all_genomes = all_genomes.OrderByDescending
			(genome => genome.score).ToList();
		}
			
		public void mutate(int mutation_rate)
		{
			foreach(Genome individual in all_genomes)
			{
				individual.mutate(mutation_rate);
			}
		}

		public void roulette_wheel_selection(int elitism)
		{
			List<Genome> wheel = new List<Genome>();
			int size = all_genomes.Count();
			for (int x = 0; x < size; x++)
			{
				for(int i = 0; i <= all_genomes[x].score ; i++)
				{
					wheel.Add(all_genomes[x]);
				}
			}
				
			for(int i = elitism; i < size ; i++)
			{
				var pick1 = rnd.Next(wheel.Count());
				var pick2 = rnd.Next(wheel.Count());
				var a = wheel[pick1];
			 	var b = wheel[pick2];
				Genome child = crossover(a,b); 
				all_genomes[i] = child;
			}
		}

		public Genome crossover(Genome a, Genome b)
		{
			var cut_pos = a.dice.Next(a.genetic_material.Count());
			for (int x = cut_pos ; x < a.genetic_material.Count()-1; x++)
			{
				a.genetic_material[x] = b.genetic_material[x];
			}
			a.score = 0;
			return a;
		}

		public Population(string solution_space, int dna_length, int population_size)
		{
			logos = solution_space;
			this.dna_length = dna_length;
		}
}
