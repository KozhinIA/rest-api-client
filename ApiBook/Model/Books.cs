/* 
 * Books
 *
 * JSON web API for Project Gutenberg ebook metadata
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = ApiBook.Client.SwaggerDateConverter;

namespace ApiBook.Model
{
    /// <summary>
    /// Books
    /// </summary>
    [DataContract]
        public partial class Books :  IEquatable<Books>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Books" /> class.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="next">next.</param>
        /// <param name="previous">previous.</param>
        /// <param name="results">results.</param>
        public Books(int? count = default(int?), string next = default(string), string previous = default(string), List<Book> results = default(List<Book>))
        {
            this.Count = count;
            this.Next = next;
            this.Previous = previous;
            this.Results = results;
        }
        
        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [DataMember(Name="count", EmitDefaultValue=false)]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or Sets Next
        /// </summary>
        [DataMember(Name="next", EmitDefaultValue=false)]
        public string Next { get; set; }

        /// <summary>
        /// Gets or Sets Previous
        /// </summary>
        [DataMember(Name="previous", EmitDefaultValue=false)]
        public string Previous { get; set; }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name="results", EmitDefaultValue=false)]
        public List<Book> Results { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Books {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Next: ").Append(Next).Append("\n");
            sb.Append("  Previous: ").Append(Previous).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Books);
        }

        /// <summary>
        /// Returns true if Books instances are equal
        /// </summary>
        /// <param name="input">Instance of Books to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Books input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Count == input.Count ||
                    (this.Count != null &&
                    this.Count.Equals(input.Count))
                ) && 
                (
                    this.Next == input.Next ||
                    (this.Next != null &&
                    this.Next.Equals(input.Next))
                ) && 
                (
                    this.Previous == input.Previous ||
                    (this.Previous != null &&
                    this.Previous.Equals(input.Previous))
                ) && 
                (
                    this.Results == input.Results ||
                    this.Results != null &&
                    input.Results != null &&
                    this.Results.SequenceEqual(input.Results)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Count != null)
                    hashCode = hashCode * 59 + this.Count.GetHashCode();
                if (this.Next != null)
                    hashCode = hashCode * 59 + this.Next.GetHashCode();
                if (this.Previous != null)
                    hashCode = hashCode * 59 + this.Previous.GetHashCode();
                if (this.Results != null)
                    hashCode = hashCode * 59 + this.Results.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}