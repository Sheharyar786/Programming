<Query Kind="Program" />

void Main()
{
	List<PostComment> comments = new List<PostComment>();
	comments.Add(new PostComment() { Id = 1, Detail = "Main Post" });
	comments.Add(new PostComment() { Id = 2, Detail = "Main Child1 Comment", ParentId = 1 });
	comments.Add(new PostComment() { Id = 3, Detail = "Main Child2 Comment", ParentId = 1 });
	comments.Add(new PostComment() { Id = 4, Detail = "Main Child3 Comment", ParentId = 1 });
	comments.Add(new PostComment() { Id = 5, Detail = "Main Child4 Comment", ParentId = 1 });
	comments.Add(new PostComment() { Id = 6, Detail = "Child 1", ParentId = 2 });
	comments.Add(new PostComment() { Id = 7, Detail = "Child 2", ParentId = 2 });
	comments.Add(new PostComment() { Id = 8, Detail = "Child 1", ParentId = 3 });
	comments.Add(new PostComment() { Id = 9, Detail = "Child 2", ParentId = 3 });
	comments.Add(new PostComment() { Id = 10, Detail = "Child 1", ParentId = 4 });
	comments.Add(new PostComment() { Id = 11, Detail = "Child 2", ParentId = 4 });
	comments.Add(new PostComment() { Id = 12, Detail = "Child 1", ParentId = 5 });
	comments.Add(new PostComment() { Id = 13, Detail = "Child 2", ParentId = 5 });

	foreach (var item in comments)
	{
		Console.WriteLine("Comment : {0}", item.ToString());
	}
	var tree = GetTree(comments, 1);
}

public List<PostComment> GetTree(List<PostComment> comments, int parentId)
{
	return comments
	.Where(c => c.Id == parentId)
	.Select(c => 
		new PostComment() 
		{ 
			Id = c.Id, 
			Detail = c.Detail, 
			ParentId = c.ParentId, 
			ChildComments = c.ParentId != c.Id? GetTree(comments, c.Id) : new List<PostComment>()
		}).ToList(); 
}
// Define other methods and classes here
/*
	Post has comments (one post can have mutiple comments, each comment belongs to one post) 
	each comment can have chlid comments 
	
	Comment C1 = Hello
			C11 = WhatsUp
			C12 = NothingMuch
	C1 
		C11 = Hi
		C12 = Hi 
		..
	..
*/
public class PostComment 
{
	public PostComment()
	{
		ChildComments = new List<PostComment>();
	}
	public int Id { get; set; }	
	public string Detail { get; set; }
	public int ParentId { get; set; }
	public List<PostComment> ChildComments { get; set; }
	public override string ToString()
	{
		return string.Format("Id:{0}, Detail:{1}, ParentId:{2}",this.Id, this.Detail, this.ParentId);
	}
}