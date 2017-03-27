using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Stories;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IStoryService
    {
        Guid Create(StoryDto newStory, string userId);

        void Update(StoryDto updatedStory);

        void UpdateMainImageUrl(Guid storyId, string imageUrl);

        int StarOrUnstar(Guid storyId, string userId);

        void Delete(Guid storyId);

        bool HasUserStarred(Guid storyId, string userId);

        void Comment(Guid storyId, string userId, string comment);

        IEnumerable<Story> Get(int page, int numberOfStories);

        IEnumerable<Story> Search(string searchTerm);

        IQueryable<Story> GetAll();

        Story GetById(Guid storyId);
    }
}
