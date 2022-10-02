using UnityEngine;

public sealed class ContactsPoller : IExecute
{
    private const float CollisionThresh = 0.1f;
    private readonly Collider2D _collider2D;

    private ContactPoint2D[] _contacts = new ContactPoint2D[10];
    public bool IsGround { get; private set; }
    public bool HasLeftContacts { get; private set; }
    public bool HasRightContacts { get; private set; }
    public ContactsPoller(Collider2D collider2D)
    {
         _collider2D = collider2D;
    }

    public void Execute()
    {
        IsGround = false;
        HasLeftContacts = false;
        HasRightContacts = false;


        var _contactsCount =_collider2D.GetContacts(_contacts);
        for (int i = 0; i < _contactsCount; i++)
        {
            var normal = _contacts[i].normal;
            var rigidbody = _contacts[i].rigidbody;

            if (normal.y>CollisionThresh)
            {
                IsGround = true;
            }
            if (normal.x>CollisionThresh && rigidbody == null)
            {
                HasLeftContacts = true;
            }
            if (normal.x< -CollisionThresh && rigidbody == null)
            {
                HasRightContacts = true;
            }
        }
    }
}
