using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krovato.Domain.Attributes.Entities
{
    public class AttributeOption
    {
        public Guid Id { get; set; }
        public Guid AttributeDefinitionId { get; set; }
        public required string Value { get; set; }
        public string? Translation { get; set; }
        public int SortOrder { get; set; }

        public required AttributeDefinition AttributeDefinition { get; set; }
    }

}
