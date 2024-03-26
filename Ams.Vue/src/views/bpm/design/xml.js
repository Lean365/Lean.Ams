/**
 * 添加flowable扩展
 * @param {*} xmlstr 
 * @returns 
 */
export function addFlowable(xmlstr) {
  const part1 = xmlstr.slice(0, 43); // 从开头到指定位置之前的部分
  const part2 = xmlstr.slice(43); // 从指定位置到末尾的部分
  const newString = part1 + 'xmlns:flowable="http://flowable.org/bpmn" ' + part2; // 拼接成新的字符串

  return newString
}

/**
* 添加属性信息
* @param {*} xmlstr 
* @returns 
*/
export function addProp(xmlstr, Elements, key, value) {
  // 创建一个XML文档对象
  const parser = new DOMParser();
  const xmlDoc = parser.parseFromString(xmlstr, 'application/xml');

  // 查找元素
  const userTaskElement = xmlDoc.getElementsByTagName(Elements);
  for (let i = 0; i < userTaskElement.length; i++) {
    if (!userTaskElement[i].attributes[key]) {
      userTaskElement[i].setAttribute(key, value);
    }
  }

  // 将修改后的XML文档转换回字符串
  const xmlSerializer = new XMLSerializer();
  const modifiedXmlString = xmlSerializer.serializeToString(xmlDoc);

  return modifiedXmlString;
}

/**
*根据标签名称返回xml内容，标签名必须唯一，若不满足，修改方法
* @param {*} xmlstr xml字符串
* @param {element} tagName 标签名称，如<Name>
*/
export function getTypeNameByTag(xmlstr, tagName) {
  const parser = new DOMParser()
  const xmlDoc = parser.parseFromString(xmlstr, 'application/xml')
  const nameNodes = xmlDoc.getElementsByTagName(tagName)[0]
  if (nameNodes) {
    return nameNodes
  } else {
    return false
  }
}

/**
* 根据标签名称修改内容
* @param {*} xmlstr xml字符串
* @param {element} tagName 标签名称，如<Name>
* @param {*} key 修改对应key
* @param {*} value 修改值value
* @returns 
*/
export function setValueByTag(xmlstr, tagName, key, value) {
  // 字符串转xml
  const parser = new DOMParser()
  const xmlDoc = parser.parseFromString(xmlstr, 'application/xml')
  const nameNodes = xmlDoc.getElementsByTagName(tagName)[0]
  nameNodes.setAttribute(key, value);
  // xml转字符串
  const s = new XMLSerializer();
  const xml = s.serializeToString(xmlDoc);

  return xml;
}
