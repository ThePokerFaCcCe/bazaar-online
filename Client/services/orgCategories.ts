const childParentFinder = (array: any) => {
  let hasParent: any = [];
  hasParent = array.filter((item: any) => item.parentId !== null);
  hasParent.forEach((child: any) => {
    hasParent.forEach((subchild: any) => {
      if (child.id === subchild.parentId) {
        const index = hasParent.indexOf(child);
        if (hasParent[index].children) {
          hasParent[index].children = [...hasParent[index].children, subchild];
          hasParent = hasParent.filter((item: any) => item.id !== subchild.id);
        } else {
          hasParent[index].children = [subchild];
          hasParent = hasParent.filter((item: any) => item.id !== subchild.id);
        }
      }
    });
  });
  return hasParent;
};

const parentFinder = (category: any, children: any) => {
  let output = category.filter((item: any) => item.parentId === null);
  category.forEach((parent: any) => {
    children.forEach((child: any) => {
      if (parent.id === child.parentId) {
        const index = output.indexOf(parent);
        if (output[index].children) {
          output[index].children = [...output[index].children, child];
        } else {
          output[index].children = [child];
        }
      }
    });
  });
  return output;
};

export const organaizeCategories = (category: any) => {
  const subChild = childParentFinder(category);
  const data = parentFinder(category, subChild);
  console.log(data);
  return data;
};
