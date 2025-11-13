//a simple genetic algorithm in csharps blazor to run in browser

public class Genome
{
	Random dice = new Random();
	public string logos {get; set;}
	public List<char> genetic_material = new List<char>();

	public void init(int dna_length)
	{
		for(int x=0;x<dna_length;x++)
		{
			char[] tmp = logos.ToCharArray(); 
			genetic_material.Add(tmp[0]);
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
	public string logos {get;set;}
	public int dna_length {get;set;}
	
	public void init(int size)
	{
		for(int x = 0; x < size ; x++)
		{
			Genome individual = new Genome(logos);
			individual.init(dna_length);
			all_genomes.Add(individual);
		}

	}

	public Population(string solution_space, int dna_length, int population_size)
	{
		logos = solution_space;
		this.dna_length = dna_length;
	}
	
}

