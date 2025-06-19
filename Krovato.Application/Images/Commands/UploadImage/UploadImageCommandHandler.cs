using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krovato.Application.Interfaces;
using Krovato.Domain.Media.Entities;
using MediatR;


namespace Krovato.Application.Images.Commands.UploadImage
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;

        public UploadImageCommandHandler(IKrovatoDbContext dbContext) => _dbContext = dbContext;
        public Task<Unit> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var image = new Image
            {
                Url = request.Url,
                AltText = request.AltText
            };

            _dbContext.Images.Add(image);
            _dbContext.SaveChangesAsync(cancellationToken);
            return Task.FromResult(Unit.Value);
        }
    }
}
