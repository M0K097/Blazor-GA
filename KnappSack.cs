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


