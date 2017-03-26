using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Stories;

using System;
using System.Collections.Generic;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IStoryService
    {
        Guid Create(StoryDto newProject, string userId);

        void Update(StoryDto updatedStory);

        void UpdateMainImageUrl(Guid storyId, string imageUrl);

        int StarOrUnstar(Guid storyId, string userId);

        bool HasUserStarred(Guid storyId, string userId);

        void Comment(Guid storyId, string userId, string comment);

        IEnumerable<Story> GetAll();

        Story GetById(Guid storyId);
    }
}
