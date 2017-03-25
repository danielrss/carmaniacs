using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IStoryService
    {
        Guid Create(StoryDto newProject, string userId);

        void Update(StoryDto updatedStory);

        //void UpdateImageUrl(Guid projectId, string imageUrl);

        IEnumerable<Story> GetAll();

        Story GetById(Guid storyId);
    }
}
