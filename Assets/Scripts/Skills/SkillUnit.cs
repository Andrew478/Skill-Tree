using UnityEngine;

public class SkillUnit
{
    public int id;
    public string name;
    public int cost;
    public bool isLearned;

    public int[] unitsToLearn; // ������, ������ ��� �������� ����� ������. ���� id = -1, �� ������ ������ ������� �� �����.

    public SkillUnit(int id, string name, int cost, bool isLearned, int[] unitsToLearn)
    {
        this.id = id;
        this.name = name;
        this.cost = cost;
        this.isLearned = isLearned;
        this.unitsToLearn = unitsToLearn;
    }

    public void Unlock()
    {
        isLearned = true;
        SaveChanges();
    }
    public int Lock()
    {
        if (id == 1) return 0; // ������� ����� ������ ������
        if (!isLearned) return 0;

        isLearned = false;
        SaveChanges();
        return cost;
    }
    void SaveChanges()
    {
        // ��������� �� ���� ������ ������ ����� ��� ���.
    }
}
