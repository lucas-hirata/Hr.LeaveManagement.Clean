﻿namespace Hr.LeaveManagement.Domain.Common;

public abstract record BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
