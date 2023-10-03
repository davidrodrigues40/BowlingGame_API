﻿using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Repositories;
using BowlingGame.Dto.Models;

namespace BowlingGame.Files.Repository;
public class MenuRepository : BaseListFileRepository<MenuItem>, IMenuRepository, IFileRepository
{
    private readonly string _fileName = "menu.json";
    public override string FileName => _fileName;

    public IEnumerable<IMenuItem> GetMenuItems() => Get(_fileName);
}
