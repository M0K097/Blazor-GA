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
			var chance = dice.Next(100);
			var pos = dice.Next(genetic_material.Count()-1);
				if (chance < mutation_rate)
				{
					var new_pick = dice.Next(logos.Count() - 1);
					genetic_material[pos] = logos[new_pick];
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

		public List<Genome> roulette_wheel_selection(List<Genome> genomes)
		{
			List<Genome> next_generation = new List<Genome>();
			List<Genome> offspring = new List<Genome>();
			int sum_fitness = genomes.Sum(x => x.score);
			
			while(next_generation.Count() < genomes.Count())
			{

				var random = rnd.Next(sum_fitness);
				int comulative = 0;
				for(int x = 0; x < genomes.Count(); x++ )
				{
					comulative += genomes[x].score;
					if(comulative >= random)
					{
						offspring.Add(genomes[x]);
						if(offspring.Count() > 1)
						{
							next_generation.AddRange(crossover(offspring[0],offspring[1]));
							offspring.Clear();
							break;
						}
					}
				}
				
			}
			return next_generation;
		}

		public List<Genome> crossover(Genome a, Genome b)
		{
			var cut_pos = a.dice.Next(a.genetic_material.Count()-1);
			List<char> tmp_material = new List<char>(a.genetic_material);
			for (int x = 0 ; x < a.genetic_material.Count(); x++)
			{
				if (x < cut_pos)
				{
					a.genetic_material[x] = b.genetic_material[x];
					b.genetic_material[x] = tmp_material[x];
				}
			}
			a.score = 0;
			b.score = 0;
			return new List<Genome>(){a,b};
		}

		public Population(string solution_space, int dna_length, int population_size)
		{
			logos = solution_space;
			this.dna_length = dna_length;
		}
}
