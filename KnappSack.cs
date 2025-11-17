using System.ComponentModel.DataAnnotations;
public class CItem
{
	[Required(ErrorMessage="NAME REQUIRED")]
	public string? name {get;set;}
	[Range(1,1000,ErrorMessage="wrong range")]
	public int weight {get;set;}
	[Range(1,1000,ErrorMessage="wrong range")]
	public int worth {get;set;}
	public bool picked {get;set;}

	public void init(string name,int weight, int worth)
	{
		this.name = name;
		this.weight = weight;
		this.worth = worth;
	}
}

public class item_settings
{
	[Required(ErrorMessage="you need some capacity")]
	[Range(1,10000,ErrorMessage="must be between 1 - 10000")]
	public int capacity {get;set;}=1;

	public void generate(int amount)
	{

	}
}


