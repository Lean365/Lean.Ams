<template>
  <div>
    <p>当前您选择了: {{form.province}}-{{form.city}}-{{form.region}}-{{form.street}}-{{form.village}}</p>
    <el-form>
      <el-form-item label="行政区划">
        <div>
          <el-select clearable filterable v-model="form.province" placeholder="省级" @change="changePr">
            <el-option v-for="item in provinceList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.city" placeholder="市级" @change="changeCi">
            <el-option v-for="item in cityList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.region" placeholder="区级" @change="changeRe">
            <el-option v-for="item in regionList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.street" placeholder="街道" @change="changeSt">
            <el-option v-for="item in streetList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.village" placeholder="村社区">
            <el-option v-for="item in villageList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
        </div>
      </el-form-item>
    </el-form>
  </div>
</template>

<script setup name="regionCnData">
  import pacas from './pcasv.json'

  let data = pacas;//格式化后的json字符串形式
  let form = ref({
    province: '', // 行政区划——省市自治区
    city: '', // 行政区划——市区
    region: '', // 行政区划——区县
    street: '', // 行政区划——乡镇街道
    village: '', // 行政区划——村社区
  })
  let provinceList = ref([]) // 存放省市自治区数据集合
  let cityList = ref([]) // 存放市区数据集合
  let regionList = ref([]) // 存放区县数据集合
  let streetList = ref([]) //存放乡镇街道数据集合
  let villageList = ref([]) //存放村社区数据集合

  onMounted(() => {
    //获取省
    provinceList.value = data
  })
  //获取市区
  const changePr = () => {
    for (var key of data) {
      if (key.name == form.value.province) {
        cityList.value = key.children
        form.value.city = key.children[0].name //默认选择第一个显示
      }
    }
    changeCi()
    changeRe()
    changeSt()
  }
  //获取区县
  const changeCi = () => {
    cityList.value.forEach((item, index) => {
      if (item.name == form.value.city) {
        regionList.value = item.children
        form.value.region = item.children[0].name //默认选择第一个显示
      }
    })
    changeRe()
    changeSt()
  }
  //获取乡镇
  const changeRe = () => {
    regionList.value.forEach((item1, index1) => {
      if (item1.name == form.value.region) {
        streetList.value = item1.children
        form.value.street = item1.children[0].name  //默认选择第一个显示
        return;
      }
    })
    changeSt()
  }
  //获取村社区
  const changeSt = () => {
    console.log(streetList)
    streetList.value.forEach((itemVi, indexVi) => {
      if (itemVi.name == form.value.street) {
        villageList.value = itemVi.children
        form.value.village = itemVi.children[0].name  //默认选择第一个显示
        return;
      }
    })

  }


</script>

<style>
</style>