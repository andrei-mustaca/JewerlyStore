document.addEventListener("DOMContentLoaded", function (){
    document.getElementById('min-price').addEventListener('input',updatePriceValues);
    document.getElementById('max-price').addEventListener('input',updatePriceValues);

    function updatePriceValues(){
        const Min= document.getElementById('min-price').value;
        const Max= document.getElementById('max-price').value;

        document.getElementById('price-values').innerText=`${Min} - ${Max}`;
    }
    
    document.getElementById('apply-filter').addEventListener('click',()=>{
       const Min=document.getElementById('min-price').value;
       const Max=document.getElementById('max-price').value;
       
       const filterData={
           priceMin:Min,
           priceMax:Max,
       };
       console.log('Отправленные данные',filterData);
       
       fetch('Products/Filter',{
           method:'POST',
           headers:{
               'Content-Type':'application/json',
           },
           body:JSON.stringify(filterData),
       })
           .then((response)=>{
               if (!response.ok){
                   throw new Error('Ошибка фильтрации данных');
               }
               return response.json();
           })
           .then((data)=>{
               console.log(data);
               dataDisplay(data);
           })
           .catch((error)=>{
               console.error('Ошибка:',error);
           })
    });
    
    
    function dataDisplay(data){
        const productList=document.querySelector('.list-products');
        productList.innerHTML="";
        
        if (!data || data.length===0){
            const errors=`<h2>По данному фильтру нет товаров</h2>`;
            productList.innerHTML=errors;
        }else{
            data.forEach((product)=>{
                const productItem=`
                <div class="list-products">
                    <div class="product-item">
                        <img src="${product.pathImage}" class="item-product-img"/>
                        <div class="item-info">
                         <h2>${product.name}<h2>
                         <h2>${product.cost}<h2>
                         <h2>${product.createdAt}<h2>
                        </div>
                    </div>
                   <input asp-for="@item.Id" value="${product.id}" style="display:none"/>
                   <input asp-for="@item.IdCategories" value="${product.idCategories}" style="display: none"/> 
                </div>        
                `;
                productList.innerHTML+=productItem;
            });
        }
        location.reload();
    }
});
