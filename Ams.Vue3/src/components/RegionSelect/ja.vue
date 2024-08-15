<template>
  <div>
    <p>現在選択されている: {{form.province}}-{{form.city}}</p>
    <el-form>
      <el-form-item label="照会">
        <div>
          <el-select clearable filterable v-model="form.province" placeholder="都道府県" @change="changePr">
            <el-option v-for="item in provinceList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.city" placeholder="市区町村">
            <el-option v-for="item in cityList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
        </div>
      </el-form-item>
    </el-form>
  </div>
</template>

<script setup name="regionJaData">
  import pacas from './jp.json'

  let data = pacas;//格式化后的json字符串形式
  let form = ref({
    province: '', // 行政区划——都道府県
    city: '', // 行政区划——市区町村

  })
  let provinceList = ref([]) // 存放都道府県数据集合
  let cityList = ref([]) // 存放市区町村数据集合


  onMounted(() => {
    //获取都道府県
    provinceList.value = data
  })
  //获取市区町村
  const changePr = () => {
    for (var key of data) {
      if (key.name == form.value.province) {
        cityList.value = key.children
        form.value.city = key.children[0].name //默认选择第一个显示
      }
    }

  }




</script>

<style>
</style>